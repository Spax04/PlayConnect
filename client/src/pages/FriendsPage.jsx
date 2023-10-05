import React, { useEffect, useState } from 'react'
import SearchBar from '../components/SearchBar'
import axios from 'axios'

import './styles/friends.css'
import FriendData from '../components/FriendData'
import { useSelector } from 'react-redux'

function FriendsPage () {
  const [friendList, setFriendList] = useState([])
  const user = useSelector(state => state.user);

  useEffect(() => {

    const getFriends = async ()=>{

      await axios
        .get(
          `${process.env.REACT_APP_IDENTITY_SERVICE_URL}/api/user/friends/${user.userid}`
        )
        .then(({ data }) => {
          setFriendList(data)
        })
        .catch(err => console.log(err))
    }

    getFriends()
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
