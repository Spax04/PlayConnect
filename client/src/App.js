import './App.css';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import Container from 'react-bootstrap/Container'
import {

  BrowserRouter,
  Route,
  Routes
} from 'react-router-dom'
import HomePage from './pages/HomePage';
import LoginPage from './pages/AuthPages/LoginPage';
import SigninPage from './pages/AuthPages/SigninPage';
import { ROUTES } from './constants';
import './styles/Home.css'
import axios from 'axios';

function App() {
  console.log(process.env.REACT_APP_IDENTITY_SERVICE_URL);

  return (
    <BrowserRouter>

      <div className="d-flex flex-column side-allpage h-100 App">
        <ToastContainer position='bottom-center' limit={1} />

        <main >
          <Container className="main-content">
            <Routes>
              <Route path={ROUTES.HOME_PAGE} element={<HomePage />} />
              <Route path={ROUTES.LOGIN_PAGE} element={<LoginPage />} />
              <Route path={ROUTES.SIGNIN_PAGE} element={<SigninPage />} />
            </Routes>
          </Container>
        </main>
      </div>
    </BrowserRouter>
  
  );
}

export default App;
