import styled from "styled-components"
import Contact from "./Contact";

export default function ContactsList(){
    return(
        <Ul>
            <li className="SearchLi">
                <input
                    type="text"
                    placeholder="Search Contacts"/>
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
    & .SearchLi{
        background-color: #fff;
        border-bottom: 1px solid #e0e0e0;
    }
    & input{
        width: calc(100% - 20px);
        padding-left: 10px;
        padding-right: 10px;
        height:40px;
        border:none;
        font-size: 16px;
        outline:none;
        
    }
    @media (min-width: 1024px) {
        width:350px
    }
`;