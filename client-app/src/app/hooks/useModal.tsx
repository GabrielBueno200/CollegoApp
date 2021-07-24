import React, { useState } from 'react';
import Modal from '../common/Modal/index';

type ModalHookReturn = [
    boolean,
    () => void,
    React.FC
];

type ModalHookParams = [
    string,
    React.FC
]

const useModal = ( [ title, Component ] : ModalHookParams ) : ModalHookReturn  => {

    const [ showModal, setShowModal ] = useState<boolean>(false);
    
    const openModal = () => setShowModal(true);

    const closeModal = () => setShowModal(false);

    const CustomModal: React.FC = ({ children }) => 
        <>
            <Modal title={title} onClose={closeModal}>
                
                <Component/>

            </Modal>
        </>

    return [showModal, openModal, CustomModal]

}

export default useModal;