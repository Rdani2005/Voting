"use client";

import {
    createContext,
    useContext,
    Dispatch,
    SetStateAction,
    useState,
} from "react";

interface ContextProps {
    actualVoter: VotersModel | null;
    setActualVoter: Dispatch<SetStateAction<VotersModel | null>>;
}

const VoterGlobalContext = createContext<ContextProps>({
    actualVoter: null,
    setActualVoter: (): void => {},
});

export const VoterGlobalContextProvider = ({
    children,
}: {
    children: React.ReactNode;
}) => {
    const [actualVoter, setActualVoter] = useState<null | VotersModel>(null);

    return (
        <VoterGlobalContext.Provider
            value={{
                actualVoter,
                setActualVoter,
            }}
        >
            {children}
        </VoterGlobalContext.Provider>
    );
};

export const useVoterContext = () => useContext(VoterGlobalContext);
