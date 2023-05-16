"use client";

import {
    createContext,
    useContext,
    Dispatch,
    SetStateAction,
    useState,
} from "react";

interface ContextProps {
    actualSupportUser: SupportUserModel | null;
    setActualSupportUser: Dispatch<SetStateAction<SupportUserModel | null>>;
    filterVoters: VotersModel[];
    setFilterVoters: Dispatch<SetStateAction<VotersModel[]>>;
    voters: VotersModel[];
    setVoters: Dispatch<SetStateAction<VotersModel[]>>;
    availableYears: YearModel[];
    setAvailableYears: Dispatch<SetStateAction<YearModel[]>>;
    availableSpec: SpecialtyModel[];
    setAvailableSpec: Dispatch<SetStateAction<SpecialtyModel[]>>;
}

const GlobalContext = createContext<ContextProps>({
    actualSupportUser: null,
    setActualSupportUser: (): void => {},
    voters: [],
    setVoters: (): void => {},
    filterVoters: [],
    setFilterVoters: (): void => {},
    availableYears: [],
    setAvailableYears: (): void => {},
    availableSpec: [],
    setAvailableSpec: (): void => {},
});

export const GlobalContextProvider = ({
    children,
}: {
    children: React.ReactNode;
}) => {
    const [actualSupportUser, setActualSupportUser] =
        useState<SupportUserModel | null>(null);
    const [voters, setVoters] = useState<[] | VotersModel[]>([]);
    const [filterVoters, setFilterVoters] = useState<[] | VotersModel[]>([]);
    const [availableSpec, setAvailableSpec] = useState<[] | SpecialtyModel[]>(
        []
    );
    const [availableYears, setAvailableYears] = useState<[] | YearModel[]>([]);

    return (
        <GlobalContext.Provider
            value={{
                actualSupportUser,
                setActualSupportUser,
                voters,
                setVoters,
                availableYears,
                setAvailableYears,
                availableSpec,
                setAvailableSpec,
                filterVoters,
                setFilterVoters,
            }}
        >
            {children}
        </GlobalContext.Provider>
    );
};

export const useGlobalContext = () => useContext(GlobalContext);
