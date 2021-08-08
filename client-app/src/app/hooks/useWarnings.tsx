import React, { useState } from 'react';
import Warnings from '../common/Warnings';

type WarningHookReturn = [
    boolean,
    () => void,
    React.FC
];

type WarningHookParams = [
    any,
    boolean,
    boolean
];

const useWarnings = ( [ data, areErrors, isAlertWarning ] : WarningHookParams ) : WarningHookReturn  => {

    const [ showWarnings, setShowWarnings ] = useState<boolean>(false);
    
    const openWarnings = () => setShowWarnings(true);

    const closeWarnings = () => setShowWarnings(false);

    const CustomWarnings: React.FC = ({ children }) => 
        <Warnings 
            data={ data } 
            areErrors={ areErrors } 
            onClose={ closeWarnings } 
            isAlertWarning={ isAlertWarning }
        />

    return [showWarnings, openWarnings, CustomWarnings];

}

export default useWarnings;