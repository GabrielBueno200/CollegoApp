import React from 'react';
import './styles.scss';
import { GrClose } from 'react-icons/gr';

interface IProps {
    title: string;
    onClose: () => void;
};


const Modal: React.FC<IProps> = ({ title, onClose, children }) => {

    return (
        
        <>
            <div className="modal-backdrop" onClick={onClose}></div>

            <div className="modal-background">

                <div className="modal-header">

                    { title } <GrClose onClick={onClose}/>
                    
                </div>

                <div className="modal-content">

                    { children }

                </div>

            </div>
            
        </>
    )

};

export default Modal;