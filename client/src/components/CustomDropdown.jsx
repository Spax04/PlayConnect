import React, { useState } from 'react';
import { IoIosNotificationsOutline, IoMdNotifications } from 'react-icons/io';
import './styles/customDropdown.css'; // Custom CSS for styling

const CustomDropdown = () => {
  const [notificationsCount, setNotificationsCount] = useState(0);
  const [isOpen, setIsOpen] = useState(false);

  const handleNotificationClick = () => {
    // Logic to handle notification click
    // For demonstration, let's just set notifications count to 0
    setNotificationsCount(0);
    setIsOpen(true);
  };

  return (
    <div className="custom-dropdown">
      <div className="notification-icon" onClick={handleNotificationClick}>
        {notificationsCount > 0 ? (
          <>
            <IoMdNotifications />
            <div className="notification-badge">{notificationsCount}</div>
          </>
        ) : (
          <IoIosNotificationsOutline />
        )}
      </div>
      {/* Dropdown content */}
      {isOpen && (
        <div className="dropdown-content">
          {notificationsCount > 0 ? (
            // Render notification items
            <ul>
              {/* Your notification items go here */}
            </ul>
          ) : (
            // Render no notifications message
            <p>There are no notifications yet.</p>
          )}
        </div>
      )}
    </div>
  );
};

export default CustomDropdown;
