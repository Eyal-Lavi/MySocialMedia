import {forwardRef, useState} from 'react'
import styled from 'styled-components';
import Login from './Login';
import Register from './Register';
import CloseButton from '../utils/ExitButton';

const AuthModal = forwardRef(function AuthModal({} , ref){
    const [authMode , setAuthMode] = useState(true);

    return <DialogStyled ref={ref} className="auth-modal">

        <form id='defualtForm' method="dialog">
            <CloseButton>X</CloseButton>
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
    overflow: hidden;

    &::backdrop{
        background-color: rgba(0, 0, 0, 0.7);
    }

    #defualtForm{
        // background-color: red;
        display: flex;
        justify-content:end;
        height:44px;
        padding-right:4px;
        padding-top:4px;
    }

    & #mainAuth{
        // background-color: coral;
        // height:100%;
        height:calc(100% - 48px);

        display:flex;
        align-items:center;
    }
`;