import { AppBar, Box, Button, Toolbar, Typography } from "@mui/material";
import UserMenu from "../UserMenu/UserMenu";

const Header: React.FC = () => {
  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static" color="inherit">
        <Toolbar>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            Goglobe
          </Typography>
          <Button color="inherit" href="/agencies">
            Agentūros
          </Button>
          <Button color="inherit" href="/login">
            Prisijungti
          </Button>
          <Button color="inherit" href="/register">
            Registruotis
          </Button>
          {/* <UserMenu /> */}
        </Toolbar>
      </AppBar>
    </Box>
  );
};

export default Header;
