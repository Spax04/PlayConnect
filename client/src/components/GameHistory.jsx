import React from 'react'
import './styles/gameHistory.css'

function GameHistory (props) {
  return (
    <div className='mainBlock'>
      {props.isWin ? (
        <div className='statusDiv'>
          <img
            alt='winner'
            className='icon'
            src={require('../assets/winner.png')}
          />
          <p className='statusText'>Winner</p>
        </div>
      ) : (
        <div className='statusDiv'>
          <img
            alt='loser'
            className='icon'
            src={require('../assets/loser.png')}
          />
          <p className='statusText'>Loser</p>
        </div>
      )}

      <div>
        <h6 className='ditailText'>1/2/2023</h6>
        <p className='ditailText'>Against: David</p>
        <div className='gameDiv'>
          <img
            alt='tic-tac-toe'
            className='icon'
            src={require('../assets/tic-tac-toe.png')}
          />
        </div>
      </div>
    </div>
  )
}

export default GameHistory
