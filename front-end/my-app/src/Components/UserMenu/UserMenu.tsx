import { Button, Menu, MenuItem, PropTypes } from "@mui/material";
import PersonIcon from "@mui/icons-material/Person";
import { useState } from "react";

interface UserMenuProps {
  name: string;
}

const UserMenu: React.FC<UserMenuProps> = ({ name }) => {
  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
  const open = Boolean(anchorEl);
  const handleClick = (event: React.MouseEvent<HTMLButtonElement>) => {
    setAnchorEl(event.currentTarget);
  };
  const handleClose = () => {
    setAnchorEl(null);
  };

  return (
    <div>
      <Button
        id="basic-button"
        aria-controls={open ? "basic-menu" : undefined}
        aria-haspopup="true"
        aria-expanded={open ? "true" : undefined}
        onClick={handleClick}
      >
        {name}
        <PersonIcon />
      </Button>
      <Menu
        id="basic-menu"
        anchorEl={anchorEl}
        open={open}
        onClose={handleClose}
        MenuListProps={{
          "aria-labelledby": "basic-button",
        }}
      >
        <MenuItem onClick={handleClose}>Profilis</MenuItem>
        <MenuItem onClick={handleClose}>Mano užsakymai</MenuItem>
        <MenuItem onClick={handleClose}>Atsijungti</MenuItem>
      </Menu>
    </div>
  );
};

export default UserMenu;
