import React, { useState } from 'react'

/* Icons */
import { MdErrorOutline } from 'react-icons/md';
import { AiFillCloseCircle } from 'react-icons/ai';
import { GoVerified } from 'react-icons/go';

/* Styles */
import './styles.scss';

/* Models */
import { ISuccess } from '../../store/reducers/models/success';

interface IProps{
    areErrors?: boolean;
    isAlertWarning: boolean;
    data: any | ISuccess;
    onClose: () => void;
};

const Warnings: React.FC<IProps> = ({ areErrors, data, isAlertWarning, onClose }) => {

    const isSuccess = !isAlertWarning && !areErrors;


    return (
        data ? 

            <div className=
                {
                `default-warnings 
                ${!!areErrors ? 'errors' : ''}
                ${isSuccess ? 'success' : ''}`
                }
            >
                
                <div className="default-warnings-content">

                    <h3 className="title">
                        {
                            isSuccess ?
                                (<><GoVerified/> {data.title}</>)
                            
                            : areErrors ? 
                                (<><MdErrorOutline/> Erro!</>)

                            : <></>
                        }
                    </h3>


                    {
                        isSuccess ?

                            <>{data.body}</>

                        : areErrors ? (

                            <ul>{

                                data.errors.map( ( { message } : { message: string }, idx: number ) =>
                                    <li key={idx}> - { message }</li>
                                )

                            }</ul>
                            
                        )

                        : <></>
                    }          

                </div> 

                <div className="default-warnings-closer" onClick={ onClose }>
                    <AiFillCloseCircle/>
                </div>

            </div>

        : <></>

    );
};

export default Warnings;
