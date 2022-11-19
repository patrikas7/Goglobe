import {
  Box,
  Container,
  createTheme,
  CssBaseline,
  Grid,
  ThemeProvider,
} from "@mui/material";
import { useEffect, useState } from "react";
import { dummHeroPost, dummyOffer } from "../../Utils/dummy";
import api from "../Api/api";
import Filters from "../Filters/Filters";
import LoadingSpinner from "../LoadingSpinner/LoadingSpinner";
import HeroPost from "./HeroPost";
import TravelOffer from "./TravelOffer";

const TravelOffers: React.FC = () => {
  const [travelOffers, setTravelOffers] = useState<any[]>([]);
  const [isLoading, setIsLoading] = useState(true);
  const theme = createTheme();

  useEffect(() => {
    const getTravelOffers = async () => {
      const { data } = await api.get("/travelOffers");
      setTravelOffers(data);
      setIsLoading(false);
    };

    getTravelOffers();
  }, []);

  return (
    <>
      <LoadingSpinner isOpen={isLoading} />
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
                    {travelOffers?.map((offer, index) => (
                      <TravelOffer
                        title={offer.city.name}
                        date={`${offer.departureDate.slice(
                          0,
                          10
                        )} - ${offer.returnDate.slice(0, 10)}`}
                        description={offer.description}
                        image={dummyOffer.image}
                        imageLabel={dummyOffer.imageLabel}
                        price={offer.price}
                        peopleCount={offer.personCount}
                        key={index}
                      />
                    ))}
                  </Grid>
                </Grid>
              </Grid>
            </Box>
          </main>
        </Container>
      </ThemeProvider>
    </>
  );
};

export default TravelOffers;
