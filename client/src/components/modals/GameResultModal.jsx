import React, { useEffect, useState } from 'react'
import Button from 'react-bootstrap/Button'
import Modal from 'react-bootstrap/Modal'
import { useDispatch, useSelector } from 'react-redux'
import '../styles/friendListModal.css'
import { EVENTS, ROUTES } from '../../constants'
import ProgressBar from 'react-bootstrap/ProgressBar'
import { calculateGameResult } from '../../utils/calculateGameResult'

function GameResultModal ({ show, handleClose, isWon }) {
  const game = useSelector(state => state.game)
  const user = useSelector(state => state.user)

  const { newLvl, newPoints, pointsToNextLvl } = calculateGameResult(
    game.currentSession.gameTypeStats.gameLvl,
    game.currentSession.gameTypeStats.gamePoints
  )

  const progress = Math.min(
    Math.min((newPoints / pointsToNextLvl) * 100, 100)
  ).toFixed(2)

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>{isWon ? 'You winner' : 'You loser'}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        {game.currentSession.gameTypeStats.gameLvl !== newLvl ? (
          <p>Level Up!</p>
        ) : (
          <></>
        )}
        <p>User's Current Level: {newLvl}</p>
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
