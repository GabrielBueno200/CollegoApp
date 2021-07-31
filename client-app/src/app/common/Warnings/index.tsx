import React, { useState } from 'react'

/* Icons */
import { MdErrorOutline } from 'react-icons/md';
import { AiFillCloseCircle } from 'react-icons/ai';


/* Styles */
import './styles.scss';

interface IProps{
    areErrors?: boolean;
    data: any;
    onClose: () => void;
};

const Warnings: React.FC<IProps> = ({ areErrors, data, onClose }) => {


    return (
        
        <div className={`default-warnings ${!!areErrors ? 'errors' : ''}`}>
            
            <div className="default-warnings-content">

                {areErrors && <h3 className="title"><MdErrorOutline/> Erro!</h3>}

                {areErrors && (
                    <ul>{

                        data.errors.map( ( { message } : { message: string }, idx: number ) =>
                            <li key={idx}> - { message }</li>
                        )

                    }</ul>
                )}          

            </div> 

            <div className="default-warnings-closer" onClick={ onClose }>
                <AiFillCloseCircle/>
            </div>

        </div>
        
    );
};

export default Warnings;
