import React, { useEffect, useState } from 'react'
import Button from 'react-bootstrap/Button'
import Modal from 'react-bootstrap/Modal'
import { useDispatch, useSelector } from 'react-redux'
import '../styles/friendListModal.css'
import { EVENTS, ROUTES } from '../../constants'
import ProgressBar from 'react-bootstrap/ProgressBar'
import { calculateGameResult } from '../../utils/calculateGameResult'

function GameResultModal ({ show, handleClose, isWon, isTie }) {
  const game = useSelector(state => state.game)
  const user = useSelector(state => state.user)
  const [progress, setProgress] = useState()
  const [lvl, setLvl] = useState()
  const [opponentId, setOpponentId] = useState()

  const [points, setPoints] = useState()

  useEffect(() => {
    if (show) {
      const { newLvl, newPoints, pointsToNextLvl } = calculateGameResult(
        game.currentSession.gameTypeStats.gameLvl,
        game.currentSession.gameTypeStats.gamePoints,
        isWon,
        isTie
      )
      const opponent = game.currentSession.participants.find(
        p => p.participantId !== user.userid && p.isPlayer === true
      )
      setLvl(newLvl)
      setPoints(newPoints)

      setProgress(
        Math.min(Math.min((newPoints / pointsToNextLvl) * 100, 100)).toFixed(2)
      )
      game.connection.invoke(EVENTS.GAME.SERVER.GAME_OVER, {
        gameSessionId: game.currentSession.sessionId,
        playerId: user.userid,
        opponentId: opponent.opponentId,
        gameTypeId: game.currentSession.gameTypeId,
        newLevel: newLvl,
        newPoints: newPoints,
        isWinner: isWon
      })
    }
  }, [show])

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>{isWon ? 'You winner' : 'You loser'}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <p>Old Points: {game.currentSession.gameTypeStats.gamePoints}</p>
        <p>New Points: {points}</p>
        {game.currentSession.gameTypeStats.gameLvl !== lvl ? (
          <p>Level Up!</p>
        ) : (
          <></>
        )}
        <p>User's Current Level: {lvl}</p>
        <ProgressBar now={progress} label={`${progress}%`} />{' '}
        {/* Progress bar */}
        <Modal.Footer>
          <Button variant='secondary' onClick={handleClose}>
            Close
          </Button>
        </Modal.Footer>
      </Modal.Body>
    </Modal>
  )
}

export default GameResultModal
