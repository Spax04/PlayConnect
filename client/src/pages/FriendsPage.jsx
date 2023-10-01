import React, { useState } from 'react'
import SearchBar from '../components/SearchBar'

import './styles/friends.css'
import FriendData from '../components/FriendData'

function FriendsPage () {
  return (
    <div className='friendsMainBlock'>
      <SearchBar />
      <div className='friendList'>
        <FriendData username='Alex' isOnline={true} countryCode='ua' favoriteGame={'Tic-Tac-Toe'} />
        <FriendData username='Anton' isOnline={false} countryCode='ru' favoriteGame={'Backgammon'}/>
        <FriendData username='Ariel' isOnline={true} countryCode='il' favoriteGame={'Chess'}/>
        
      </div>
    </div>
  )
}

export default FriendsPage
