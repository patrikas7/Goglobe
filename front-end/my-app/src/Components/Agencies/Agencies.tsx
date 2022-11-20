import {
  Container,
  createTheme,
  CssBaseline,
  Grid,
  ThemeProvider,
} from "@mui/material";
import { useEffect, useState } from "react";
import api from "../Api/api";
import LoadingSpinner from "../LoadingSpinner/LoadingSpinner";
import Agency from "./Agency";

const Agences: React.FC = () => {
  const theme = createTheme();
  const [agencies, setAgencies] = useState<any[] | null>(null);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const getAgencies = async () => {
      const response = await api.get("/agencies");
      setAgencies(response.data);
      setIsLoading(false);
    };

    getAgencies();
  }, []);

  return (
    <>
      <LoadingSpinner isOpen={isLoading} />
      <ThemeProvider theme={theme}>
        <CssBaseline />
        <Container maxWidth={false} sx={{ m: 4 }}>
          <main>
            <Grid
              container
              spacing={{ xs: 2, md: 3 }}
              columns={{ xs: 4, sm: 8, md: 12 }}
            >
              {agencies?.map((agency, index) => (
                <Grid item xs={2} sm={4} md={4} key={index}>
                  <Agency name={agency.name} address={agency.address} />
                </Grid>
              ))}
            </Grid>
          </main>
        </Container>
      </ThemeProvider>
    </>
  );
};

export default Agences;
