import React from 'react'

/* Icons */
import { AiFillCloseCircle } from 'react-icons/ai';

/* Styles */
import './styles.scss';

/* Utils */
import { AlertWarning, ErrorWarning, SuccessWarning } from './strategy';

interface IProps{
    areErrors?: boolean;
    isAlertWarning: boolean;
    data: any;
    onClose: () => void;
};

const Warnings: React.FC<IProps> = ({ areErrors, data, isAlertWarning, onClose }) => {
    
    const Warning = !isAlertWarning && !areErrors ? SuccessWarning(data)
                                      : areErrors ? ErrorWarning(data)
                                      : AlertWarning(data);

    return (
        data ? 

            <div className= {`default-warnings ${ Warning.className }`}>
                
                <div className="default-warnings-content">

                    <h3 className="title"> <Warning.Title/> </h3>

                    <Warning.Body/>

                </div> 

                <div className="default-warnings-closer" onClick={ onClose }>
                    <AiFillCloseCircle/>
                </div>

            </div>

        : <></>

    );
};

export default Warnings;
