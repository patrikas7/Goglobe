import {
  Container,
  createTheme,
  CssBaseline,
  Grid,
  ThemeProvider,
} from "@mui/material";
import { useEffect } from "react";
import { dummHeroPost, dummyOffer } from "../../Utils/dummy";
import api from "../Api/api";
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
      <Container maxWidth="lg">
        <main>
          <HeroPost
            image={dummHeroPost.image}
            imageText={dummHeroPost.imageText}
            title={dummHeroPost.title}
          />
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
        </main>
      </Container>
    </ThemeProvider>
  );
};

export default TravelOffers;
