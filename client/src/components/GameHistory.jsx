import React, { useEffect, useState } from 'react';
import { blobToURL } from '../utils/blobToURL';
import './styles/gameHistory.css';

import winnerIcon from '../assets/winner.png';
import loserIcon from '../assets/loser.png';

function GameHistory({ isWin, gameTypeId, gameDate }) {
  const [img, setImg] = useState();
  const [gameName, setGameName] = useState();
  const [formattedDateTime, setFormattedDateTime] = useState('');

  useEffect(() => {
    const gameTypes = JSON.parse(sessionStorage.getItem('gameTypes'));

    const gameType = gameTypes.find(gt => gt.id === gameTypeId);
    setGameName(gameType.name);

    const createImage = async () => {
      const imgUrl = await blobToURL(gameType.image);
      setImg(imgUrl);
    };
    createImage();

    // Format the date
    const date = new Date(gameDate);
    const formattedDate = formatDate(date);
    const formattedTime = formatTime(date);
    setFormattedDateTime({ formattedDate, formattedTime });
  }, [gameTypeId, gameDate]);

  // Function to format date as dd/mm/yyyy
  const formatDate = (date) => {
    const day = date.getDate();
    const month = date.getMonth() + 1;
    const year = date.getFullYear();
    return `${day}/${month}/${year}`;
  };

  // Function to format time as hh:mm
  const formatTime = (date) => {
    const hours = date.getHours();
    const minutes = date.getMinutes();
    return `${hours}:${minutes < 10 ? '0' : ''}${minutes}`;
  };

  return (
    <div className={`mainBlock ${isWin ? 'winner' : 'loser'}`}>
      <div className='leftContent'>
      <div className='statusDiv'>
          <img
            alt={isWin ? 'winner' : 'loser'}
            className='icon'
            src={isWin ? winnerIcon : loserIcon}
          />
          <p className='statusText'>{isWin ? 'Winner' : 'Loser'}</p>
        </div>

       
      </div>
      <div className='middleContent'>
      <div className='gameDiv'>
          <img
            alt={gameName}
            className='gameIcon'
            src={img}
          />
          <p className='gameName'>{gameName}</p>
        </div>
      </div>
      <div className='rightContent'>
        <div className='dateTime'>
          <p className='formattedDate'>{formattedDateTime.formattedDate}</p>
          <p className='formattedTime'>{formattedDateTime.formattedTime}</p>
        </div>
      </div>
    </div>
  );
}

export default GameHistory;
