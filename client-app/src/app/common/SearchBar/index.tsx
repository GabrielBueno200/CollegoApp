import React from 'react';
import { AiOutlineSearch } from 'react-icons/ai';
import './styles.scss';

const SearchBar: React.FC = () => {
    return (
        <div className="default-search-bar">
            <button className="search-button"><AiOutlineSearch className="search-icon"/></button>
            <input className="search-input" placeholder="Procure por sua dúvida" type="text"/>
        </div>
    );
}

export default SearchBar;