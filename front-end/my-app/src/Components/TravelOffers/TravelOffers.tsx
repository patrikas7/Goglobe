import {
  Box,
  Container,
  createTheme,
  CssBaseline,
  Grid,
  ThemeProvider,
} from "@mui/material";
import { useEffect } from "react";
import { dummHeroPost, dummyOffer } from "../../Utils/dummy";
import api from "../Api/api";
import Filters from "../Filters/Filters";
import HeroPost from "./HeroPost";
import TravelOffer from "./TravelOffer";

const TravelOffers: React.FC = () => {
  const theme = createTheme();

  useEffect(() => {
    const getTravelOffers = async () => {
      const data = await api.get("/travelOffers");
      console.log(data);
    };

    getTravelOffers();
  }, []);

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Container maxWidth={false}>
        <main>
          <HeroPost
            image={dummHeroPost.image}
            imageText={dummHeroPost.imageText}
            title={dummHeroPost.title}
          />
          <Box sx={{ flexGrow: 1 }}>
            <Grid container spacing={2}>
              <Grid item xs={2}>
                <Filters />
              </Grid>
              <Grid item xs={10}>
                <Grid container spacing={4}>
                  <TravelOffer
                    title={dummyOffer.title}
                    date={dummyOffer.date}
                    description={dummyOffer.description}
                    image={dummyOffer.image}
                    imageLabel={dummyOffer.imageLabel}
                  />

                  <TravelOffer
                    title={dummyOffer.title}
                    date={dummyOffer.date}
                    description={dummyOffer.description}
                    image={dummyOffer.image}
                    imageLabel={dummyOffer.imageLabel}
                  />

                  <TravelOffer
                    title={dummyOffer.title}
                    date={dummyOffer.date}
                    description={dummyOffer.description}
                    image={dummyOffer.image}
                    imageLabel={dummyOffer.imageLabel}
                  />

                  <TravelOffer
                    title={dummyOffer.title}
                    date={dummyOffer.date}
                    description={dummyOffer.description}
                    image={dummyOffer.image}
                    imageLabel={dummyOffer.imageLabel}
                  />
                </Grid>
              </Grid>
            </Grid>
          </Box>
        </main>
      </Container>
    </ThemeProvider>
  );
};

export default TravelOffers;
