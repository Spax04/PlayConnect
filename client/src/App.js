
//import './App.css';
// import { ToastContainer } from 'react-toastify';
// import 'react-toastify/dist/ReactToastify.css';
// import Container from 'react-bootstrap/Container'
// import {

//   BrowserRouter,
//   Route,
//   Routes
// } from 'react-router-dom'
// import HomePage from './pages/HomePage';
// import LoginPage from './pages/AuthPages/LoginPage';
// import SigninPage from './pages/AuthPages/SigninPage';

import { useSockets } from './context/socket.context';
import { useEffect, useRef } from 'react';
import Messages from './components/Messages';
import Rooms from './components/Rooms';
import './styles/Home.css'

function App() {

  const { state, dispatch } = useSockets();
  const userNameRef = useRef(null);

  const { username } = state

  useEffect(() => {
    if (userNameRef) {
      userNameRef.current.value = localStorage.getItem('username') || ''
    }
  }, [])


  const handelSetUsername = () => {
    const value = userNameRef.current.value;

    if (!value) {
      return;
    }

    dispatch({ type: 'SET_USERNAME', payload: value })

    localStorage.setItem('username', value)
  }

  return (
    // <BrowserRouter>

    //   <div className="d-flex flex-column side-allpage h-100 App">
    //     <ToastContainer position='bottom-center' limit={1} />

    //     <main >
    //       <Container className="main-content">
    //         <Routes>
    //           <Route path='/' element={<HomePage />} />
    //           <Route path='/login' element={<LoginPage />} />
    //           <Route path='/signin' element={<SigninPage />} />
    //         </Routes>
    //       </Container>
    //     </main>
    //   </div>
    // </BrowserRouter>
    <div>
      {!username && <div className='usernameWrapper'>
        <div className='usernameInner'>

          <input placeholder='Username' ref={userNameRef} />
          <button onClick={handelSetUsername}>Start</button>
        </div>
      </div>}

      {username && <div className='container'>

        <Messages />
        <Rooms />
      </div>}

    </div>
  );
}

export default App;
