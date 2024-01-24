import React,{useState} from 'react'
import TicTicToeBoard from '../../components/gameComponents/ticTacToe/TicTicToeBoard'
import '../styles/ticTacToe.css'
function TicTacToeGamePage () {
  const [history, setHistory] = useState([{ squares: Array(9).fill(null) }])
  const [stepNumber, setStepNumber] = useState(0)
  const [xIsNext, setXIsNext] = useState(true)

  const current = history[stepNumber]
  const winner = calculateWinner(current.squares)

  const handleClick = i => {
    const newHistory = history.slice(0, stepNumber + 1)
    const currentBoard = newHistory[newHistory.length - 1]
    const squares = currentBoard.squares.slice()

    if (winner || squares[i]) {
      return
    }

    squares[i] = xIsNext ? 'X' : 'O'

    setHistory(newHistory.concat([{ squares }]))
    setStepNumber(newHistory.length)
    setXIsNext(!xIsNext)
  }

  

  return (
    <div className='game'>
      <div className='game-board'>
        <TicTicToeBoard squares={current.squares} onClick={handleClick} />
      </div>
      <div className='game-info'>
        <div>
          {winner ? `Winner: ${winner}` : `Next player: ${xIsNext ? 'X' : 'O'}`}
        </div>
        {/* <ol>{renderMoves()}</ol> */}
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
