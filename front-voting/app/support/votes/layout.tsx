import AppBar from "@/components/AppBar";
import "../../globals.css";
import { Inter } from "next/font/google";

const inter = Inter({ subsets: ["latin"] });

const now: Date = new Date();

export const metadata = {
    title: `Resultados ${now.getFullYear()}`,
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
                {children}
            </body>
        </html>
    );
}
