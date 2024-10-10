import styled from "styled-components"
import Contact from "./Contact";
import SearchIcon from '/SearchIcon.png'
export default function ContactsList(){
    return(
        <Ul>
            <li className="SearchLi">
                <input
                    type="text"
                    placeholder="Search Contacts"/>
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
        </Ul>
    )
}
const Ul = styled.ul`
    background-color:blue;
    height:100%;
    box-shadow: 10px 0px 15px 0px rgba(23,203,212,0.36);
    // box-shadow: 10px 0px 12px 0px rgba(34,40,49,0.49);
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
        width:300px
    }
`;