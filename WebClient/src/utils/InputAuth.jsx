import React from 'react'
import styled from 'styled-components'
import { forwardRef } from 'react';
export default forwardRef(function InputAuth({children ,textarea ,label ,...props}, ref) {
  return (
    <Parag>
        <label htmlFor="">
            {label}
        </label>
        {textarea ?
            <textarea ref={ref} className='respoStyleInputs' {...props}/>  :
            <input ref={ref} className='respoStyleInputs' type="text" {...props}/>}
    </Parag>
  )
});


const Parag = styled.p`
    width:80%;
    max-width: 450px;
    display: flex;
    flex-direction: column;
    
    & label{
        font-size: 16px;
        color: #333333;
        font-weight: bold;
        margin-bottom:3px;
    }
    .respoStyleInputs{
        border:none;
        width:100%;
        border-bottom: 2px solid #cccccc; 
        background-color: #F9F9F9;
        transition: border-bottom-color 0.3s ease;
        resize:vertical;
        padding-left: 2px;
    }
    & .respoStyleInputs:focus{
        outline:none;
        border-bottom: 2px solid #006BFF;
        background-color: #FFFFFF;
    }
    & input{
        height:1.8rem;
    }
`;