import React, { useEffect } from 'react'
import { useSelector } from 'react-redux'

import { COLORS, EVENTS } from '../constants'
import { MdVideogameAsset } from 'react-icons/md'
import { MdVideogameAssetOff } from 'react-icons/md'

function GameInviteResponsePopup ({ route }) {
// const navigate = useNavigate()
  const styles = {
    changeColor: {
      color: 'black'
    },
    changeColorHover: {
      color: 'white'
    },

    nameColor: { color: '#2e2e2e' }
  }

  // useEffect(() => {
  //   navigate(route)
  // }, [])
  return (
    <div className='d-flex'>
      <h3>Connection to the game...</h3>
      <div>
        <span style={styles}>
          <MdVideogameAsset />
        </span>
      </div>
    </div>
  )
}

export default GameInviteResponsePopup
