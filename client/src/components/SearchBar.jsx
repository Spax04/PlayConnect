import React ,{useState,useEffect} from 'react'
import './styles/searchBar.css'
import Dropdown from 'react-bootstrap/Dropdown'
import {GrSearch} from 'react-icons/gr'
import { COLORS } from '../constants';


function SearchBar() {
    const [value, setValue] = useState('');
    const [suggestions, setSuggestions] = useState([]);
    const [selectedItem, setSelectedItem] = useState('Looking for...')
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
  
    return (
      <div className='searchContainer'>
        <input
          type="text"
          className='textbox'
          placeholder="Search data..."
          value={value}
          onChange={(e) => {
            setValue(e.target.value);
          }}
        />
        <button className='searchBtn'><GrSearch /></button>
        <Dropdown onSelect={handleItemSelect}>
          <Dropdown.Toggle variant='primary' id='dropdown-basic'>
            {selectedItem}
          </Dropdown.Toggle>

          <Dropdown.Menu>
            <Dropdown.Item eventKey='My Friends'>My Friends</Dropdown.Item>
            <Dropdown.Item eventKey='New Friend'>New Friend</Dropdown.Item>
          </Dropdown.Menu>
        </Dropdown>
      </div>
    );
}

export default SearchBar