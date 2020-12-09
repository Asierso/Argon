sudo echo "Requested sudo"
echo "Installing Argon"
sudo cp Argon.exe /usr/bin/argon
chmod a+x /usr/bin/argon
echo "Install sucess, installing plugins folder";
sudo cp -r Plugins /usr/lib/argon-plugins
echo "Install sucess"
echo "For use it, run 'argon' in your shell"