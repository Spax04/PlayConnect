import React, { useEffect, useState } from 'react'
import { Card, Button } from 'react-bootstrap'
import CardGroup from 'react-bootstrap/CardGroup'
import GameCard from '../../components/GameCard'
import '../styles/games.css'
import axios from 'axios'
import { useDispatch, useSelector } from 'react-redux'
import { setGameTypes } from '../../context/slices/game'
import { toast } from 'react-toastify'
import { useNavigate } from 'react-router-dom'
import FriendListModal from '../../components/modals/FriendListModal'
import { ROUTES } from '../../constants'
import CreateNewGame from '../../components/modals/CreateNewGame'

function GameMenuPage () {
  const dispatch = useDispatch()
  const navigate = useNavigate()
  const game = useSelector(state => state.game)
  const [gameTypeList, setGameTypeList] = useState([])
  const [currentGameTypeId,setCurrentGameTypeId] = useState();
  const [showFriends, setShowFriends] = useState(false)
  const [showCreateGame, setShowCreateGame] = useState(false)
  const handleCloseFriends = () => setShowFriends(false)
  const handleShowFriends = () => setShowFriends(true)

  const handleCloseCreateGame = () => setShowCreateGame(false)
  const handleShowCreateGame = () => setShowCreateGame(true)

  const getGamesList = async () => {

    let toastId = toast.loading('Loading games, wait...')

    await axios
      .get(`${process.env.REACT_APP_GAME_SERVICE_URL}/api/game/game-type`)
      .then(({ data }) => {
        console.log(data)
        dispatch(setGameTypes(data))
        setGameTypeList(data)
        toast.update(toastId, {
          render: 'Game list uploaded',
          type: toast.TYPE.SUCCESS,
          autoClose: 3000,
          closeButton: true,
          isLoading: false
        })
      })
      .catch(err =>
        toast.update(toastId, {
          render: `Some error: ${err}`,
          type: toast.TYPE.ERROR,
          autoClose: 3000,
          closeButton: true,
          isLoading: false
        })
      )
  }
  useEffect(() => {
    game.gameTypes.length === 0
      ? getGamesList()
      : setGameTypeList(game.gameTypes)

  }, [])

  return (
    <div className='gamePageMainBlock'>
      <FriendListModal show={showFriends} currentGameTypeId={currentGameTypeId} handleClose={handleCloseFriends} />
      <CreateNewGame show={showCreateGame}  handleClose={handleCloseCreateGame}/>
      <div className="buttonContainer">
        <Button variant="primary" onClick={()=>navigate(ROUTES.LOBBIES_PAGE)}>Search game</Button>
        <Button variant="success"  onClick={handleShowCreateGame}>Create New Game</Button>
      </div>
      <div className="gameCardContainer">
        {gameTypeList.map(game => (
          <GameCard
            key={game.id}
            gameTypeId={game.id}
            title={game.name}
            imgBg={game.image}
            handleShow={handleShowFriends}
            setCurrentGameTypeId={setCurrentGameTypeId}
          />
        ))}
      </div>
    </div>
  )
  
}

export default GameMenuPage
