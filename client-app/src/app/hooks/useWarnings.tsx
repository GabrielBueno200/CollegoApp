import React, { useState } from 'react';
import Warnings from '../common/Warnings';

type WarningHookReturn = [
    boolean,
    () => void,
    React.FC
];

type WarningHookParams = [
    any,
    boolean
];

const useWarnings = ( [ data, areErrors ] : WarningHookParams ) : WarningHookReturn  => {

    const [ showWarnings, setShowWarnings ] = useState<boolean>(false);
    
    const openWarnings = () => setShowWarnings(true);

    const closeWarnings = () => setShowWarnings(false);

    const CustomWarnings: React.FC = ({ children }) => 
        showWarnings ? 
            <Warnings data={ data } areErrors={ areErrors } onClose={ closeWarnings }/>
        : <></>

    return [showWarnings, openWarnings, CustomWarnings];

}

export default useWarnings;