# webdav.yandex
Nothing interesting

dotnet publish --output ./build.dev -c Release --self-contained false /p:PublishSingleFile=true -r linux-x64

# https://xakep.ru/2014/09/09/webdav/

# https://eax.me/webdav/
# apt install davfs2

mkdir -p /mnt/dav/
Присоединить webdav-сервер можно таким образом:

# для облака мейл ру
mount.davfs -o username=<login_name>@mail.ru https://webdav.cloud.mail.ru /mnt/dav
# для yandex.диска

mount.davfs -o username=<login_name>@yandex.ru https://webdav.yandex.ru /mnt/dav

gpasswd -a user_name davfs2
https://webdav.yandex.ru/ /home/main/users/user_name/dav davfs noauto,user 0 0
# https://webdav.yandex.ru/ /media/dav davfs noauto,user,rw 0 0

# mount.davfs -o username=fdsc@yandex.ru https://webdav.yandex.ru /home/main/users/inet/dav

# /etc/fstab
https://webdav.yandex.ru/ /home/main/users/user_name/dav davfs noauto,user 0 0

mount /home/main/users/user_name/dav

# /etc/davfs2/davfs2.conf
# /home/user_name/.davfs2/davfs2.conf
# use_proxy 1
# proxy 127.0.0.1:8120
# /home/user_name/.davfs2/secrets
