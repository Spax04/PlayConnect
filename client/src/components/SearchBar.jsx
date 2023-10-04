import React, { useState, useEffect } from 'react'
import './styles/searchBar.css'
import Dropdown from 'react-bootstrap/Dropdown'
import { GrSearch } from 'react-icons/gr'
import { COLORS } from '../constants'
import axios from 'axios'
import { useSelector } from 'react-redux'

function SearchBar ({ setFriendList }) {
  const [searchValue, setSearchValue] = useState('')
  const [selectedOption, setSelectedOption] = useState('Looking for...')
  const [selectedItem,setSelectedItem] = useState('Looking for...')
  const user = useSelector(state => state.user)
  const handleItemSelect = item => {
    setSelectedItem(item)
  }

  // useEffect(() => {
  //   const fetchData = async () => {
  //     try {
  //       const { data } = await axios.get(
  //         `https://dummyjson.com/products/search?q=${value}`
  //       );

  //       setSuggestions(data.products);
  //     } catch (error) {
  //       console.log(error);
  //     }
  //   };

  //   fetchData();
  // }, [value]);
  const onUsersSearch = async () => {
    await axios
      .get(
        `${process.env.REACT_APP_IDENTITY_SERVICE_URL}/api/user/${user.userid}/${searchValue}`
      )
      .then(({ data }) => {
       // console.log(data)
        setFriendList(data)
      })
      .catch(err => console.log(err))
  }
  const onFriendsSearch = async () => {
    await axios
      .get(
        `${process.env.REACT_APP_IDENTITY_SERVICE_URL}/api/user/friends/${user.userid}`
      )
      .then(({ data }) => {
        // setFriendList(data)
      })
      .catch(err => console.log(err))
  }

  const onSearch = async () => {
    console.log(searchValue)
    if (selectedItem === 'My Friends') {
      await onFriendsSearch()
    } else if (selectedItem === 'New Friends') {
      await onUsersSearch()
    }
  }
  return (
    <div className='searchContainer'>
      <input
        type='text'
        className='textbox'
        placeholder='Search user...'
        value={searchValue}
        onChange={e => {
          setSearchValue(e.target.value)
        }}
      />
      <button onClick={onSearch} className='searchBtn'>
        <GrSearch />
      </button>
      <Dropdown onSelect={handleItemSelect}>
        <Dropdown.Toggle variant='primary' id='dropdown-basic'>
          {selectedItem}
        </Dropdown.Toggle>

        <Dropdown.Menu>
          <Dropdown.Item eventKey={"My Friends"}>
            My Friends
          </Dropdown.Item>
          <Dropdown.Item eventKey={"New Friends"}>
            New Friend
          </Dropdown.Item>
        </Dropdown.Menu>
      </Dropdown>
    </div>
  )
}

export default SearchBar
