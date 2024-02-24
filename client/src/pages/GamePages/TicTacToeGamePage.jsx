import React, { useEffect, useState } from 'react'
import TicTicToeBoard from '../../components/gameComponents/ticTacToe/TicTicToeBoard'
import '../styles/ticTacToe.css'
import { useDispatch, useSelector } from 'react-redux'
import { EVENTS, ROUTES } from '../../constants'
import { generateGuid } from '../../utils/generateGuid'
import GameResultModal from '../../components/modals/GameResultModal'
import { useNavigate } from 'react-router-dom'
import { setGameOver } from '../../context/slices/game'

function TicTacToeGamePage () {
  const navigate = useNavigate()

  const [history, setHistory] = useState([{ squares: Array(9).fill(null) }])
  const [stepNumber, setStepNumber] = useState(0)
  const [currentBoard, setCurrentBoard] = useState(history[stepNumber])
  const [mySign, setMySign] = useState('')
  const [opponentName, setOpponentName] = useState('')
  const [isMyTurn, setIsMyTurn] = useState(false)
  const [winner, setWinner] = useState(null)
  const [timer, setTimer] = useState(0); // New state for timer
  const [show, setShow] = useState(false)
  const [minutes, setMinutes] = useState(0); // New state for minutes
  const [seconds, setSeconds] = useState(0);
  const dispatch = useDispatch()

  const handleClose = () => {
    setShow(false)
    navigate(ROUTES.HOME_PAGE)
    dispatch(setGameOver())
  }
  const handleShow = () => setShow(true)

  const game = useSelector(state => state.game)
  const user = useSelector(state => state.user)

  const isBoardFull = squares => {
    return squares.every(square => square !== null)
  }

  useEffect(() => {
    const interval = setInterval(() => {
      setTimer(prevTimer => prevTimer + 1);
    }, 1000);

    return () => clearInterval(interval);
  }, []);

  useEffect(() => {
    // Calculate minutes and seconds from timer
    const updatedMinutes = Math.floor(timer / 60);
    const updatedSeconds = timer % 60;
    setMinutes(updatedMinutes);
    setSeconds(updatedSeconds);
  }, [timer]);

  const formatTime = (time) => {
    return `${time < 10 ? '0' + time : time}`;
  };


  const handleClick = i => {
    if (isMyTurn) {
      const newHistory = history.slice(0, stepNumber + 1)
      const currentBoard = newHistory[newHistory.length - 1]
      const squares = currentBoard.squares.slice()

      if (winner || squares[i]) {
        return
      }

      squares[i] = mySign

      const guid = generateGuid()
      const gameMove = JSON.stringify({
        id: guid,
        gameSessionId: game.currentSession.sessionId,
        moveNumber: newHistory.length,
        gameTypeId: game.currentSession.gameTypeId,
        moveHistoryJson: JSON.stringify(newHistory.concat([{ squares }]))
      })

      game.connection.invoke(EVENTS.GAME.SERVER.MAKE_GAME_MOVE, {
        gameSessionId: game.currentSession.sessionId,
        gameTypeId: game.currentSession.gameTypeId,
        senderId: user.userid,
        gameMove: gameMove
      })
    }
  }

  useEffect(() => {
    if (game.currentSession.sessionId) {
      game.connection.invoke(EVENTS.GAME.SERVER.JOINT_TO_GAME_SESSION, {
        gameSessionId: game.currentSession.sessionId,
        playerName: user.username,
        playerId: user.userid,
        isPlayer: game.currentSession.isPlayer
      })
    }
  }, [])

  useEffect(() => {
    if (game.currentSession.gameHistory.length !== 0) {
      setHistory(game.currentSession.gameHistory)
      setStepNumber(game.currentSession.moveNumber)

      setCurrentBoard(
        game.currentSession.gameHistory[game.currentSession.moveNumber]
      )
      setWinner(
        calculateWinner(
          game.currentSession.gameHistory[game.currentSession.moveNumber]
            .squares
        )
      )

      if (
        !winner &&
        isBoardFull(
          game.currentSession.gameHistory[game.currentSession.moveNumber]
            .squares
        )
      ) {
        setWinner('Tie')
      }
    }
  }, [game.currentSession.gameHistory])

  useEffect(() => {
    if (winner) {
      handleShow()
    }
  }, [winner])

  useEffect(() => {
    if (game.currentSession.participants.length !== 0) {
      const opponent = game.currentSession.participants.find(
        p => p.isPlayer === true && p.participantId !== user.userid
      )
      setOpponentName(opponent.participantName)
      setIsMyTurn(game.currentSession.isMyTurn)
    }
    if (mySign === '') {
      const sign = game.currentSession.isMyTurn ? 'X' : 'O'
      setMySign(sign)
    }
  }, [game.currentSession.participants, game.currentSession.isMyTurn])

  return (
    <div className='game'>
      <GameResultModal
        show={show}
        handleClose={handleClose}
        isWon={winner === mySign ? true : false}
        isTie={winner === 'Tie' ? true : false}
        steps={stepNumber}
        seconds={timer} 
        maxPointPreGame={50}
      />
      <div className='game-board'>
        <h2>{formatTime(minutes)} : {formatTime(seconds)}</h2>
        <TicTicToeBoard squares={currentBoard.squares} onClick={handleClick} />
      </div>
      <div className='game-info'>
        <div>
          {winner
            ? winner === 'Tie'
              ? 'TIE'
              : `Winner: ${winner === mySign ? 'Me' : opponentName}`
            : `Current players turn: ${isMyTurn ? 'Me' : opponentName}`}
        </div>
      </div>
    </div>
  )
}

const calculateWinner = squares => {
  const lines = [
    [0, 1, 2],
    [3, 4, 5],
    [6, 7, 8],
    [0, 3, 6],
    [1, 4, 7],
    [2, 5, 8],
    [0, 4, 8],
    [2, 4, 6]
  ]

  for (let i = 0; i < lines.length; i++) {
    const [a, b, c] = lines[i]
    if (squares[a] && squares[a] === squares[b] && squares[a] === squares[c]) {
      return squares[a]
    }
  }

  return null
}

export default TicTacToeGamePage
