import { GoVerified } from "react-icons/go";
import { MdErrorOutline } from "react-icons/md";

export interface IWarningsStrategy{

    className?: string,
    Title: React.FC,
    Body: React.FC

};

export const SuccessWarning = (data: any): IWarningsStrategy  => ({

    className: 'success',

    Title: () => <><GoVerified/> { data.title }</>,

    Body: () => <>{ data.body }</>
});

export const ErrorWarning = (data: any): IWarningsStrategy => ({

    className: 'errors',

    Title: () => (<><MdErrorOutline/> Erro!</>),

    Body: () => 

        <ul>{

            data.errors.map( ( { message } : { message: string }, idx: number ) =>
                <li key={idx}> - { message }</li>
            )

        }</ul>

});

export const AlertWarning = (data: any): IWarningsStrategy => ({

    Title: () => <></>,

    Body: () => <></>

});