echo "Update Commit:"
read commit
git init
git add .
git rm "Upload.sh"
git commit -m "$commit"
git remote add origin "https://github.com/Asierso/Argon.git"
echo "Credendials:"
git push -u origin master