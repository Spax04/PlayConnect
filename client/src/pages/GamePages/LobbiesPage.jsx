import LobbyComponent from '../../components/LobbieComponent'
import React, { useState } from 'react'
import '../styles/lobbie.css'

function LobbiesPage () {
  // State to manage the list of game lobbies
  const [gameLobbies, setGameLobbies] = useState([
    {
      id: 1,
      lobbieName: 'Game 1',
      gameTypeId: '96536109-ba26-480c-9fb7-9136f8bc536d',
      lobbyName: 'Noobs welcome',
      countryCode: 'PA',
      hostLvl: 2,
      hostName:'PapaKarlo'
    },
    {
      id: 2,
      lobbieName: 'Game 2',
      gameTypeId: '96536109-ba26-480c-9fb7-9136f8bc536d',
      lobbyName: 'Min 5 lvl',
      hostLvl: 5,
      countryCode: 'UA',
      hostName: 'Zelensky'
    },
    {
      id: 3,
      lobbieName: 'Game 3',
      gameTypeId: '96536109-ba26-480c-9fb7-9136f8bc536d',
      lobbyName: 'Just make fun',
      hostLvl: 1,
      countryCode: 'IL',
      hostName:'Visozky'
    }
  ])

  return (
    <div className='lobby-container'>
      <h1 id='lobby-header'>Lobby</h1>
      <div className='game-lobbies'>
        {gameLobbies.map(lobby => (
          <LobbyComponent key={lobby.id} lobby={lobby} />
        ))}
      </div>
    </div>
  )
}

export default LobbiesPage
