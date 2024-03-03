import React, { useState } from 'react'
import { Modal, Button, Form } from 'react-bootstrap'

function CreateNewGame ({ show, handleClose }) {
  const [gameName, setGameName] = useState('')
  const [gameType, setGameType] = useState('')
  const [minLevel, setMinLevel] = useState(1)
  const [maxLevel, setMaxLevel] = useState('')
  const [minTimePerTurn, setMinTimePerTurn] = useState(30) // Default to 30 seconds
  const [minBid, setMinBid] = useState(10) // Default minimum bid amount

  const handleCreateGame = () => {
    // Handle creating the game here
  }

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Host new Game</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <Form.Group controlId='formGameName'>
            <Form.Label>Game Name</Form.Label>
            <Form.Control
              type='text'
              placeholder='Enter game name'
              value={gameName}
              onChange={e => setGameName(e.target.value)}
            />
          </Form.Group>

          <Form.Group controlId='formGameType'>
            <Form.Label>Game Type</Form.Label>
            <Form.Control
              as='select'
              value={gameType}
              onChange={e => setGameType(e.target.value)}
            >
              <option value=''>Select game type</option>
              {/* Add options for game types */}
            </Form.Control>
          </Form.Group>

          <Form.Group controlId='formLevelRange'>
            <Form.Label>Level Range</Form.Label>
            <div className='row'>
              <div className='col'>
                <Form.Control
                  type='number'
                  placeholder='Minimum Level'
                  value={minLevel}
                  onChange={e => setMinLevel(parseInt(e.target.value))}
                />
              </div>
              <div className='col'>
                <Form.Control
                  type='number'
                  placeholder='Maximum Level'
                  value={maxLevel}
                  onChange={e => setMaxLevel(parseInt(e.target.value))}
                />
              </div>
            </div>
          </Form.Group>

          <Form.Group controlId='formTimePerTurn'>
            <Form.Label>Minimal Time per Turn (seconds)</Form.Label>
            <Form.Control
              type='number'
              value={minTimePerTurn}
              onChange={e => setMinTimePerTurn(parseInt(e.target.value))}
            />
          </Form.Group>

          <Form.Group controlId='formMinBid'>
            <Form.Label>Minimal Bid (coins)</Form.Label>
            <Form.Control
              type='number'
              value={minBid}
              onChange={e => setMinBid(parseInt(e.target.value))}
            />
          </Form.Group>
        </Form>
      </Modal.Body>
      <Modal.Footer>
        <Button variant='secondary' onClick={handleClose}>
          Close
        </Button>
        <Button variant='primary' onClick={handleCreateGame}>
          Create Game
        </Button>
      </Modal.Footer>
    </Modal>
  )
}

export default CreateNewGame
