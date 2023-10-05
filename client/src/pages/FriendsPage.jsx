import React, { useEffect, useState } from 'react'
import SearchBar from '../components/SearchBar'

import './styles/friends.css'
import FriendData from '../components/FriendData'

function FriendsPage () {
  const [friendList, setFriendList] = useState([])

  useEffect(() => {
    console.log(friendList)
  }, [friendList])
  return (
    <div className='friendsMainBlock'>
      <SearchBar setFriendList={setFriendList} />
      <div className='friendList'>
        {friendList ? (
          friendList.map(friend => 
            <FriendData
            userid={friend.userid}
              username={friend.username}
              isFriend={friend.isFriend}
              isOnline={true}
              countryCode={friend.country.code}
              favoriteGame={'Tic-Tac-Toe'}
            />
          )
        ) : (
          <></>
        )}
      </div>
    </div>
  )
}

export default FriendsPage
