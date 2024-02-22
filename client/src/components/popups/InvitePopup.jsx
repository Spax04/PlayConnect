import React from 'react'
import { useSelector } from 'react-redux'
import { BiSolidMessageSquareCheck } from 'react-icons/bi'
import { BiSolidMessageSquareX } from 'react-icons/bi'
import { COLORS, EVENTS } from '../../constants'

function InvitePopup ({ guestId, gameTypeId, hostId }) {
  const game = useSelector(state => state.game)
  const friends = useSelector(state => state.friends)

  const styles = {
    changeColor: {
      color: 'black'
    },
    changeColorHover: {
      color: 'white'
    },

    nameColor: { color: '#2e2e2e' }
  }

  const responseInvite = isAccepted => {
    game.connection.invoke(EVENTS.GAME.SERVER.INVITE_RESPONSE_BY_GUEST, {
      hostId: hostId,
      guestId: guestId,
      gameTypeId: gameTypeId,
      isAccepted: isAccepted
    })
  }

  let gameInvite = game.gameTypes.find(g => g.id === gameTypeId)
  let host = friends.acceptedFriends.find(f => f.userId === hostId)
  console.log(gameTypeId)

  console.log(gameInvite)
  console.log(guestId)
  console.log(host)
  return (
    <div className='d-flex'>
      <h3>
        <span style={styles.nameColor}>{host.username} </span> invites you to{' '}
        <span style={styles.nameColor}>{gameInvite.name}</span> game.
      </h3>
      <div>
        <span style={styles}>
          <BiSolidMessageSquareCheck
            onClick={() => responseInvite(true)}
            size='2rem'
            color={COLORS.green}
            onMouseOver={({ target }) =>
              (target.style.color = COLORS.darkGreen)
            }
            onMouseOut={({ target }) => (target.style.color = COLORS.green)}
          />
        </span>
        <span style={styles}>
          <BiSolidMessageSquareX
            onClick={() => responseInvite(false)}
            size='2rem'
            color={COLORS.red}
            onMouseOver={({ target }) => (target.style.color = COLORS.darkRed)}
            onMouseOut={({ target }) => (target.style.color = COLORS.red)}
          />
        </span>
      </div>
    </div>
  )
}

export default InvitePopup
