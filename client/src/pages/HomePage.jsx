import React, { useEffect } from 'react'
import { useNavigate } from 'react-router-dom'

function HomePage () {
  const navigate = useNavigate()
  useEffect(() => {
    if (!localStorage.getItem('token')) {
      navigate('/login')
    }
  }, [])
  return <div>HomePage</div>
}

export default HomePage
