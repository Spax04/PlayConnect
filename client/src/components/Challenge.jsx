import React from 'react'
import './styles/challenge.css'
import { Col, Row } from 'react-bootstrap'
import { AiFillCloseCircle } from 'react-icons/ai/'
import { COLORS } from '../constants'
import {GiTwoCoins} from 'react-icons/gi/'

function Challenge ({ title, description, progress, prize, purpose }) {
  return (
    <div className='challengeMainBlock'>
      <div className='d-flex justify-content-between'>
        <h3 className='leftText'>{title}</h3>
        <button className='closeBtn'>
          <AiFillCloseCircle color={COLORS.red} size={24} />
        </button>
      </div>
      <Row>
        <Col>
          <p className='leftText'>{description}</p>
        </Col>
        <Col className='d-flex justify-content-around' xs={5}>
          <p className='processText'>
            {progress}/{purpose}
          </p>
          <button className='prizeBtn d-flex' disabled={progress !== purpose}>{prize} <GiTwoCoins size={24} color={COLORS.yellow}/></button>
        </Col>
      </Row>
    </div>
  )
}

export default Challenge
