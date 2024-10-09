import styled from "styled-components";
import UserIcon from '/UserIcon.png';

export default function Contact({ name = "User Name" }) {
    return (
        <Li>
            <button>
                <img src={UserIcon} alt="(user img)" />
                <span>{name}</span>
            </button>
        </Li>
    );
}

const Li = styled.li`
    background-color: #fff;
    height: 60px;
    border-bottom: 1px solid #e0e0e0;
    transition: background-color 0.3s ease;

    &:hover {
        background-color: #f1f1f1; /* שינוי צבע ברקע בעת מעבר עכבר */
    }

    & button {
        display: flex;
        align-items: center;
        justify-content: start;
        width: 100%;
        height: 100%;
        background-color: transparent;
        border: none;
        padding: 10px 15px;
        cursor: pointer;
        transition: background-color 0.3s ease, box-shadow 0.3s ease;
    }

    & button:hover {
        background-color: #f9f9f9;
        box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
    }

    & img {
        width: 40px;
        height: 40px;
        border-radius: 50%; /* תמונה עגולה */
        margin-right: 15px;
    }

    & span {
        font-size: 18px;
        color: #333;
        font-weight: bold;
    }
`;

// import styled from "styled-components"
// import UserIcon from '/UserIcon.png';

// export default function Contact(){
//     return(
//         <Li>
//             <button>
//                 <img src={UserIcon} alt="(user img)"/>
//                 asdads
//             </button>
//         </Li>
//     )
// }
// const Li = styled.li`
//     background-color:pink;
//     height: 50px;
//     border-bottom:1px solid black;
    
//     & button{
//         display:flex;
//         align-items:center;
//         justify-content: start;
//         width:100%;
//         height:100%;
//         background-color:transparent;
//         // outline:none;
//         border:none;
//         margin-bottom:2px;
//     }
//     & img{
//         width:40px;
//         margin-left: 25px;
//         margin-right: 15px;
//     }

    
// `;