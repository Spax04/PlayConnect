import React, { useEffect, useState } from 'react'
import SearchBar from '../components/SearchBar'
import axios from 'axios'
import './styles/friends.css'
import FriendData from '../components/FriendData'
import { useDispatch, useSelector } from 'react-redux'
import { setFriends,setFriendsConnectionStatus } from '../context/slices/friends'
import { Button } from 'react-bootstrap'
import { COLORS, ROUTES } from '../constants'
import { LiaUserFriendsSolid } from 'react-icons/lia'
import { BsFillPersonPlusFill } from 'react-icons/bs'
import { toast } from 'react-toastify'
import { useNavigate } from 'react-router-dom'


function FriendsPage () {
  const [friendsList, setFriendsList] = useState([])
  const navigate = useNavigate()
  const user = useSelector(state => state.user)
  const friends = useSelector(state => state.friends)
  const [isPendingList,setIsPendingList] = useState(false);


  const dispatch = useDispatch()

  const getFriends = async () => {

    await axios
      .get(
        `${process.env.REACT_APP_IDENTITY_SERVICE_URL}/api/user/friends/${user.userid}`
      )
      .then(({ data }) => {
       console.log(data);
        dispatch(setFriends(data))
       
      })
      .catch(err => console.log(err))

  }

  useEffect(() => {
    if(!user.token){
      navigate(ROUTES.LOGIN_PAGE);
    }
    if (!sessionStorage.getItem('friends')) {
      getFriends()
    }

    setFriendsList(friends.acceptedFriends)
  }, [user,friends])

  const changeFriendsList = (list) =>{

    if(list === friends.acceptedFriends){
      setIsPendingList(false)
      setFriendsList(list)
    }else{
      setIsPendingList(true)
      setFriendsList(list)
    }
  }

  return (
    <div className='friendsMainBlock'>
      <div className='d-flex justify-content-around'>

     
      <div className='d-flex justify-content-center'>
        <Button
          onClick={() => changeFriendsList(friends.acceptedFriends)}
          className='m-3'
          style={{
            background: COLORS.yellow,
            borderColor: COLORS.yellow,
            color: COLORS.dark,
            fontSize: '1rem'
          }}
        >
          <LiaUserFriendsSolid size='1.5rem' color={COLORS.dark} /> {'    '} My
          friends
        </Button>
        <Button
          onClick={() => changeFriendsList(friends.pendingFriends)}
          className='m-3 pendingBtn'
          style={{
            background: COLORS.yellow,
            borderColor: COLORS.yellow,
            color: COLORS.dark,
            fontSize: '1rem'
          }}
        >
          <BsFillPersonPlusFill size='1.5rem' color={COLORS.dark} />
          {'    '}Pending {'    '}{' '}
          <span className='pandingSpanCounter'>
            {friends.pendingFriends.length}
          </span>
        </Button>
      </div>
      <SearchBar setFriendList={setFriendsList} />
      </div>
      <div className='friendList'>
        {friendsList ? (
          friendsList.map(friend => (
            <FriendData
              key={friend.userId}
              userid={friend.userId}
              username={friend.username}
              getFriends={getFriends}
              isFriend={friend.isFriend}
              isPendingList={isPendingList}
              isConnected={friend.isConnected}
              isRequested = {friend.isRequested}
              countryCode={friend.country.code}
              favoriteGame={'Tic-Tac-Toe'}
            />
          ))
        ) : (
          <></>
        )}
      </div>
    </div>
  )
}

export default FriendsPage
