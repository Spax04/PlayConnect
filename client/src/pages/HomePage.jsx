import React, { useEffect, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import { Col, Container, Row } from 'react-bootstrap'
import Nav from 'react-bootstrap/Nav'
import NavDropdown from 'react-bootstrap/NavDropdown'
import './styles/home.css'
import { COLORS, ROUTES } from '../constants'
import GameHistory from '../components/GameHistory'
import { useSelector } from 'react-redux'
import Carousel from 'react-multi-carousel'
import 'react-multi-carousel/lib/styles.css'
import Table from 'react-bootstrap/Table'
import Challenge from '../components/Challenge'
import Spinner from 'react-bootstrap/Spinner'

const chellanges = [
  {
    title: 'Variety Champion',
    description:
      'Win a specified number of matches in different ways (e.g., horizontal, vertical, diagonal) over the course of a week.',
    progress: 0,
    purpose: 1,

    prize: 1500
  },
  {
    title: 'Lucky Streak',
    description:
      'Achieve a specified number of wins without the opponent blocking any of your winning moves.',
    progress: 0,
    purpose: 6,
    prize: 2500
  },
  {
    title: 'Ultimate Challenger',
    description:
      'Challenge a certain number of friends or opponents to matches within the week.',
    progress: 3,
    purpose: 3,

    prize: 2000
  }
]
const responsive = {
  superLargeDesktop: {
    // the naming can be any, depends on you.
    breakpoint: { max: 4000, min: 3000 },
    items: 5
  },
  desktop: {
    breakpoint: { max: 3000, min: 1024 },
    items: 4
  },
  tablet: {
    breakpoint: { max: 1024, min: 464 },
    items: 2
  },
  mobile: {
    breakpoint: { max: 464, min: 0 },
    items: 1
  }
}

function HomePage () {
  const game = useSelector(state => state.game)
  const navigate = useNavigate()
  const user = useSelector(state => state.user)

  const [gameResults, setGameResults] = useState([])
  useEffect(() => {
    if (!user.token) {
      navigate(ROUTES.LOGIN_PAGE)
    }
  }, [user])

  useEffect(() => {
    // TODO: Get request of game result only when there are game types in state
  }, [game.gameTypes])

  return (
    <Container id='container'>
      <div>
        <h1 className='lastGamesHeader'>Last games</h1>
        {gameResults ? (
          <Carousel
            className='lastGames'
            responsive={responsive}
            infinite={false}
            containerClass='lastGames-inner'
            sliderClass='slider'
          >
            <GameHistory
              isWin={false}
              gameTypeId={'96536109-ba26-480c-9fb7-9136f8bc536d'}
              gameDate={'2024-02-22T19:29:49.021253'}
            />
            <GameHistory
              isWin={true}
              gameTypeId={'96536109-ba26-480c-9fb7-9136f8bc536d'}
              gameDate={'2024-02-22T19:29:49.021253'}
            />
          </Carousel>
        ) : (
          <div className='spinner-container'>
          <Spinner animation='border' variant="light" style={{ width: "3rem", height: "3rem" }} role='status' />
          <p className='spinnereText'>Loading last games...</p>
        </div>
        )}
      </div>
      <Row className='mt-5'>
        <Col lg={4}>
          <h1 className='lastGamesHeader'>Week Leaderboard</h1>
          <div className='scoreBoard'>
            <div className='scoreBoardImg'>
              <div className='scoreImgDiv'>
                <img
                  alt='week leaders icon'
                  className='icon'
                  src={require('../assets/leaders.png')}
                />
              </div>
              <p className='scoreText'>Best of the week</p>
            </div>
            <div className='tableDiv'>
              <Table className='tableCustome' hover size='sm'>
                <thead>
                  <tr>
                    <th>#</th>
                    <th>Username</th>
                    <th>Score</th>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <td>1</td>
                    <td>Mark</td>
                    <td>5000</td>
                  </tr>
                  <tr>
                    <td>2</td>
                    <td>Jacob</td>
                    <td>4500</td>
                  </tr>
                  <tr>
                    <td>3</td>
                    <td>Larry</td>
                    <td>4000</td>
                  </tr>
                  <tr>
                    <td>4</td>
                    <td>Larry</td>
                    <td>3500</td>
                  </tr>
                  <tr>
                    <td>5</td>
                    <td>Larry</td>
                    <td>3000</td>
                  </tr>
                  <tr>
                    <td>6</td>
                    <td>Larry</td>
                    <td>2500</td>
                  </tr>
                  <tr>
                    <td>7</td>
                    <td>Larry</td>
                    <td>2000</td>
                  </tr>
                  <tr>
                    <td>8</td>
                    <td>Larry</td>
                    <td>1500</td>
                  </tr>
                  <tr>
                    <td>9</td>
                    <td>Larry</td>
                    <td>1000</td>
                  </tr>
                  <tr>
                    <td>10</td>
                    <td>Larry</td>
                    <td>500</td>
                  </tr>
                </tbody>
              </Table>
            </div>
          </div>
        </Col>
        <Col lg={8}>
          <h1 className='lastGamesHeader'>Challenges</h1>
          <div className='challenges'>
            <div className='challengesBoardImg'>
              <div className='challengesImgDiv'>
                <img
                  alt='challenges icon'
                  className='icon'
                  src={require('../assets/challenge.png')}
                />
              </div>
              <p className='challengesText'>My Weekly challenges</p>
            </div>
            {chellanges.map((i, index) => (
              <Challenge
                key={index}
                title={i.title}
                description={i.description}
                progress={i.progress}
                prize={i.prize}
                purpose={i.purpose}
              />
            ))}
          </div>
        </Col>
      </Row>
    </Container>
  )
}

export default HomePage
