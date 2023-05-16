import AppBar from "@/components/AppBar";
import "../../globals.css";
import { Inter } from "next/font/google";
import { PoliticalPartiesGlobalContextProvider } from "@/app/context/PoliticalStore";

const inter = Inter({ subsets: ["latin"] });

const now: Date = new Date();

export const metadata = {
    title: `Partidos Politicos ${now.getFullYear()}`,
    description: `Programa de Votaciones año ${now.getFullYear()}`,
};

export default function RootLayout({
    children,
}: {
    children: React.ReactNode;
}) {
    return (
        <html lang="es">
            <body className={inter.className}>
                <AppBar></AppBar>
                <PoliticalPartiesGlobalContextProvider>
                    {children}
                </PoliticalPartiesGlobalContextProvider>
            </body>
        </html>
    );
}
