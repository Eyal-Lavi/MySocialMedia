import styled from "styled-components"
import Contact from "./Contact";
import SearchIcon from '/SearchIcon.png'
import { useState } from "react";
import Arrow from '/Arrow.png';
export default function ContactsList(){
    const [contactListStatus , setContactListStatus] = useState(true);
    const handleTriangleClick = () => {
        console.log("Triangle clicked!");
        setContactListStatus(prevStatus => !prevStatus);
    };
    return(
        <Ul $status={contactListStatus}>
            {contactListStatus &&
                <>
                    <li className="SearchLi">
                        <input
                            type="text"
                            placeholder="Search Contact"/>
                        <img id="searchIcon" src={SearchIcon}/>
                    </li>
                    <Contact />
                    <Contact />
                    <Contact />
                    <Contact />
                    <Contact />
                    <Contact />
                    <Contact />
                    <Contact />
                    <Contact />
                    <Contact />
                    <Contact />
                    <Contact />
                    <Contact />
                    <Contact />
                </>}
            {/* 
                    <li className="SearchLi">
                        <input
                            type="text"
                            placeholder="Search Contact"/>
                        <img id="searchIcon" src={SearchIcon}/>
                    </li>
                    <Contact />
                    <Contact />
                    <Contact />
                    <Contact />
                    <Contact />
                    <Contact />
                    <Contact />
                    <Contact />
                    <Contact />
                    <Contact />
                    <Contact />
                    <Contact />
                    <Contact />
                    <Contact /> */}

            <Triangle onClick={handleTriangleClick}>

            </Triangle>
        </Ul>
    )
}
const Ul = styled.ul`
    background-color:#fff;
    height:100%;
    box-shadow: 10px 0px 15px 0px rgba(23,203,212,0.36);
    // box-shadow: 10px 0px 12px 0px rgba(34,40,49,0.49);
    position:relative;
    transition: width 0.7s ease;
    & .SearchLi{
        background-color: red;
        background-color: #fff;
        border-bottom: 1px solid #e0e0e0;
        display:flex;
        align-items:center;
    }
    & input{
        width: calc(100% - 60px);
        padding-left: 10px;
        padding-right: 10px;
        height:40px;
        border:none;
        font-size: 16px;
        outline:none;
    }
    & #searchIcon{
        width:30px;
        height:30px;
        // background-color:red;
    }
    @media (min-width: 1024px) {
        ${({$status})=>($status ?
            `
            width:300px;
            
            & input{
                // width:0px;//
                calc(100% - 60px)
                padding:0;
            }
            & #searchIcon{
                display:block;
                transition: display 0.7s ease;
            }
            button{
                width:100%;
            }
            span{
                opacity: 1;
                transition: opacity 0.7s ease;
                background-color:red;
            }
            img{
                transition: width 0.7s ease;
                width:40px;
            }
            `://צריך להגדיר פה את האנמציה במקרעה של הסגירה
            `
            width:0px;

            & input{
                width:0px;
                padding:0;
            }
            & #searchIcon{
                display:none;
                transition: display 0.7s ease;
            }
            button{
                width:0px;
            }
            span{
                opacity: 0;
                transition: opacity 0.3s ease;
            }
            img{
                transition: width 0.7s ease;
                width:0px;
            }
            `
        )}
    }
`;


const Triangle = styled.div`
    display:none;

    @media (min-width: 1024px) {
        display:block;
        position: absolute;
        top: 50%;
        right: -50px;
        transform: translateY(-50%);
        width: 0;
        height: 0;
        border-left: 50px solid rgba(23,203,212,0.36);
        border-top: 30px solid transparent;
        border-bottom: 30px solid transparent;
        cursor: pointer;

        &:hover {
            border-left-color: rgba(23,203,212,0.56);
        }
    }
`;