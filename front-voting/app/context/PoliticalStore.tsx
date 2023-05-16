"use client";

import {
    createContext,
    useContext,
    Dispatch,
    SetStateAction,
    useState,
} from "react";

interface ContextProps {
    politicalParties: PoliticalPartyModel[] | [];
    setPoliticalParties: Dispatch<SetStateAction<PoliticalPartyModel[] | []>>;
}

const PoliticalPartiesGlobalContext = createContext<ContextProps>({
    politicalParties: [],
    setPoliticalParties: (): void => {},
});

export const PoliticalPartiesGlobalContextProvider = ({
    children,
}: {
    children: React.ReactNode;
}) => {
    const [politicalParties, setPoliticalParties] = useState<
        PoliticalPartyModel[] | []
    >([]);

    return (
        <PoliticalPartiesGlobalContext.Provider
            value={{
                politicalParties,
                setPoliticalParties,
            }}
        >
            {children}
        </PoliticalPartiesGlobalContext.Provider>
    );
};

export const usePoliticalPartiesContext = () =>
    useContext(PoliticalPartiesGlobalContext);
