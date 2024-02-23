import React, { useEffect, useState } from 'react';
import { blobToURL } from '../utils/blobToURL';
import './styles/gameHistory.css';

function GameHistory({ isWin, gameTypeId, gameDate }) {
  const [img, setImg] = useState();
  const [gameName, setGameName] = useState();

  useEffect(() => {
    const gameTypes = JSON.parse(sessionStorage.getItem('gameTypes'));

    const gameType = gameTypes.find(gt => gt.id === gameTypeId);
    setGameName(gameType.name);

    const createImage = async () => {
      const imgUrl = await blobToURL(gameType.image);
      setImg(imgUrl);
    };
    createImage();
  }, [gameTypeId]);

  return (
    <div className={`mainBlock ${isWin ? 'winner' : 'loser'}`}>
      <div className='statusDiv'>
        <img
          alt={isWin ? 'winner' : 'loser'}
          className='icon'
          src={isWin ? require('../assets/winner.png') : require('../assets/loser.png')}
        />
        <p className='statusText'>{isWin ? 'Winner' : 'Loser'}</p>
      </div>

      <div className='detailsBlock'>
        <div className='gameDiv'>
          <img
            alt={gameName}
            className='gameIcon'
            src={img}
          />
          <p className='gameName'>{gameName}</p>
        </div>
        <h6 className='detailText'>{gameDate}</h6>
      </div>
    </div>
  );
}

export default GameHistory;
