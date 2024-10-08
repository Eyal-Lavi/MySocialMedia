import { useContext, useRef } from "react";
import { AuthContext } from "../store/authentication-info-context";
import styled from "styled-components";
import InputAuth from "../utils/InputAuth";
import TextButton from "../utils/TextButton";
import SubmitButton from "../utils/SubmitButton";
const Register = ({updateAuthMode}) => {
    const authCtx = useContext(AuthContext);
    const firstnameRef = useRef();
    const lastnameRef = useRef();
    const usernameRef = useRef();
    const passwordRef = useRef();
    
    const handleSubmit = (event) => {
        event.preventDefault();
        //some code to complete register
        console.log("Form submitted (register)");
    };
    const handleHaveNotAccount = ()=>{
        updateAuthMode(prevValue => !prevValue);
    };
    return(
        <FormStyled onSubmit={handleSubmit} >
        <h1  className="bebas-font">Register</h1>
        <InputAuth
             ref = {firstnameRef}
             label="First Name"
             type="text"
           />
        <InputAuth
             ref = {lastnameRef}
             label="Last Name"
             type="text"
           />
         <InputAuth
             ref = {usernameRef}
             label="User Name"
             type="text"
           />
         <InputAuth
             ref = {passwordRef}
             label="Password"
             type="password"
            />
        <SubmitButton type="submit">Send</SubmitButton>

        <TextButton onClick={handleHaveNotAccount}>Arleady have account ?</TextButton>
     </FormStyled>
    )
}

const FormStyled = styled.form`
    width:100%;
    height:100%;

    display:flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-between;
`;
export default Register;