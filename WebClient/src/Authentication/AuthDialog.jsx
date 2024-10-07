import {forwardRef, useState} from 'react'
import styled from 'styled-components';
import Login from './Login';
import Register from './Register';

const AuthModal = forwardRef(function AuthModal({} , ref){
    const [authMode , setAuthMode] = useState(true);

    return <DialogStyled ref={ref} className="auth-modal">

        <form id='defualtForm' method="dialog">
            <button>X</button>
        </form>
        <div id='mainAuth'>
            {authMode ?
                <Login updateAuthMode={setAuthMode}/> :
                <Register updateAuthMode={setAuthMode}/>}
        </div>
    </DialogStyled>
});
export default AuthModal;

const DialogStyled = styled.dialog`
    position: fixed;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    background-color: #ececec;
    width: 600px;
    height: 500px;
    border:none;
    border-radius:20px;

    &::backdrop{
        background-color: rgba(0, 0, 0, 0.7);
    }

    #defualtForm{
        // background-color: red;
        display: flex;
        justify-content:end;
        height:44px;
    }
    
    #defualtForm button{
        background-color: transparent;
        border: none;
        border: 2px solid rgba(255, 255, 255, 0.5);
        border-radius: 24px;
        font-size: 18px;
        padding: 5px 8px;
        color: white;
        margin:5px;
    }
    #defualtForm button:hover{
        background-color: #006BFF;
        color: #EDDFE0;
    }
    #defualtForm button:hover {
        background-color: rgba(0, 107, 255, 0.8);
        box-shadow: 0 0 15px rgba(0, 107, 255, 0.6); 
    }
    #defualtForm button:hover::before {
        opacity: 1;
    }

    & #mainAuth{
        // background-color: coral;
        // height:100%;
        height:calc(100% - 44px);

        display:flex;
        align-items:center;
    }
`;