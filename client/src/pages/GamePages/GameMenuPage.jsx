import React,{useState} from 'react'
import { Card } from 'react-bootstrap'
import CardGroup from 'react-bootstrap/CardGroup'
import GameCard from '../../components/GameCard'
import FriendListModal from '../../components/FriendListModal'
import '../styles/games.css'

function GameMenuPage () {

  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  return (
    <div className='gamePageMainBlock'>
      <FriendListModal show={show} handleClose={handleClose}/>
      <GameCard
        title={'Tic Tac Toe'}
        description={
          'Tic-tac-toe is a two-player game played on a 3x3 grid. Each player takes turns placing an X or O on the grid. The first player to get three of their marks in a row wins the game.'
        }
        imgBg={require('../../assets/tic-tac-toeLogo.jpg')}
        handleShow={handleShow}
      />

      <GameCard
        title={'Battle Ship'}
        imgBg={require('../../assets/battleshipLogo.png')}
        description={
          "Battleship is a two-player game where players secretly arrange their ships and take turns firing to sink their opponent's fleet."
        }
        handleShow={handleShow}
      />
      <GameCard
        title={'Checkers'}
        imgBg={require('../../assets/checkersLogo.png')}
        description={
          "Checkers is a two-player strategy board game where players strategically move their pieces across an 8x8 checkered board, aiming to capture all of their opponent's pieces or block them from making any further moves."
        }
        handleShow={handleShow}
      />
    </div>
  )
}

export default GameMenuPage
