import React from 'react'
import { useEffect, useState } from 'react';
import { useNavigate,useLocation } from 'react-router-dom';

function useNavigationToGamePage(route) {
    const navigate = useNavigate();
  
    useEffect(() => {
        navigate(route)
      }, []);
  
    return ;
}

export default useNavigationToGamePage