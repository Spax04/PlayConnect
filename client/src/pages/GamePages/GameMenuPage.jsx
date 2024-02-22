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

function GameMenuPage () {
  const dispatch = useDispatch()
  const game = useSelector(state => state.game)
  const [gameTypeList, setGameTypeList] = useState([])
  const [currentGameTypeId,setCurrentGameTypeId] = useState();
  const [show, setShow] = useState(false)
  const handleClose = () => setShow(false)
  const handleShow = () => setShow(true)

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
    <FriendListModal show={show} currentGameTypeId={currentGameTypeId} handleClose={handleClose} />

      {gameTypeList.map(game => {
        return (
          <GameCard
            key={game.id}
            gameTypeId={game.id}
            title={game.name}
            imgBg={game.image}
            handleShow={handleShow}
            setCurrentGameTypeId={setCurrentGameTypeId}
          />
        )
      })}
      
    </div>
  )
}

export default GameMenuPage
